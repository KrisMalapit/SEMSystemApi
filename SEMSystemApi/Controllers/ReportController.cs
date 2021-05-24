using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using SEMSystemApi.Models;

namespace SEMSystemApi.Controllers
{
    public class ReportController : ApiController
    {

        private SEMEntities db = new SEMEntities();
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/greet")]
        public string Greet()
        {

            try
            {
                this.WriteLog("greet", true);
                return "Hi";
            }
            catch (Exception e)
            {

                return e.Message.ToString();
                throw;
            }


        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/printreport")]

        public byte[] PrintReports(string rvm)
        {


            var o = JsonConvert.DeserializeObject(rvm);
            ReportViewModel rptVM = JsonConvert.DeserializeObject<ReportViewModel>(rvm);
            string report = rptVM.Report;

            try
            {
                DataSet ds = new DataSet();
                LocalReport LocalReport = new LocalReport
                {
                    ReportPath = baseDir + "\\Reports\\" + report + ".rdlc"
                };
                DateTime def = new DateTime(1, 1, 1);
                if (rptVM.Report == "rptFireExtinguisher")
                {
                    //var v = db.FireExtinguisherDetails
                    //    .Where(a => a.FireExtinguisherHeaderId == rptVM.ReferenceId) //A
                    //  .GroupJoin(
                    //     db.LocationFireExtinguishers // B
                    //     .Where(a => a.Status == "Active"),
                    //     i => i.LocationFireExtinguisherId, //A key
                    //     p => p.Id,//B key
                    //     (i, g) =>
                    //        new
                    //        {
                    //            i, //holds A data
                    //            g  //holds B data
                    //        }
                    //  )
                    //  .SelectMany(
                    //     temp => temp.g.Take(1).DefaultIfEmpty(), //gets data and transfer to B
                    //     (A, B) =>
                    //        new
                    //        {

                    //            Id = A.i.LocationFireExtinguisherId,
                    //            Plant = B.Area.Company.Name,
                    //            B.Area.CompanyId,
                    //            Area = B.Area.Name,
                    //            B.Location,
                    //            A.i.CreatedAt,
                    //            B.Code,
                    //            B.Type,
                    //            B.Capacity,
                    //            A.i.Cylinder,
                    //            A.i.Lever,
                    //            A.i.Gauge,
                    //            A.i.SafetySeal,
                    //            A.i.Hose,
                    //            A.i.Remarks,
                    //            A.i.InspectedBy,
                    //            A.i.ReviewedBy,
                    //            A.i.NotedBy

                    //        }
                    //  );


                    var v = db.FireExtinguisherDetails
                    .Where(a => a.FireExtinguisherHeaders.Status == "Active")
                     .Where(a => a.FireExtinguisherHeaderId == rptVM.ReferenceId)//A
                    .GroupJoin(
                            db.LocationFireExtinguishers // B
                            .Where(a => a.Status == "Active"),
                            i => i.FireExtinguisherHeaders.LocationFireExtinguisherId, //A key
                            p => p.Id,//B key
                            (i, g) =>
                                new
                                {
                                    i, //holds A data
                                    g  //holds B data
                                }
                            )
                            .SelectMany(
                            temp => temp.g.DefaultIfEmpty(), //gets data and transfer to B
                            (A, B) =>
                                 new
                                 {

                                     id = A.i.ItemId,
                                     ItemName = A.i.Items.Name,
                                     A.i.Cylinder,
                                     A.i.Lever,
                                     A.i.Gauge,
                                     A.i.SafetySeal,
                                     A.i.Hose,
                                     A.i.Remarks,
                                     A.i.Items.Code,
                                     B.Type,
                                     B.Capacity,
                                     A.i.InspectedBy,
                                     A.i.ReviewedBy,
                                     A.i.NotedBy,
                                     CompanyName = B.Areas.Companies.Name,
                                     HeaderId = A.i.FireExtinguisherHeaderId,
                                     B.Location,
                                     Plant = B.Areas.Companies.Name,
                                     CompanyId = B.Areas.Companies.ID,
                                     Area = B.Areas.Name,
                                     A.i.CreatedAt,


                                 }
                            );





                    //if (rptVM.fromDate != def)
                    //{
                    //    v = v.Where(a => a.CreatedAt >= rptVM.fromDate && a.CreatedAt <= rptVM.toDate);
                    //}
                    var lsts = v.OrderBy(a => a.ItemName).ToList();
                    DataTable dts = new DataTable();
                    dts = ToDataTable(lsts);
                    ReportDataSource datasources = new ReportDataSource("FireExtinguisher", dts);
                    LocalReport.DataSources.Clear();
                    LocalReport.DataSources.Add(datasources);
                    return LocalReport.Render(rptVM.rptType);

                }
                else if (rptVM.Report == "rptEmergencyLight")
                {
                    //var v = db.EmergencyLightDetails
                    //           .Where(a => a.EmergencyLightHeaderId == rptVM.ReferenceId)//A                                              
                    //           .GroupJoin(
                    //              db.LocationEmergencyLights // B
                    //              .Where(a => a.Status == "Active"),
                    //              i => i.LocationEmergencyLightId, //A key
                    //              p => p.Id,//B key
                    //              (i, g) =>
                    //                 new
                    //                 {
                    //                     i, //holds A data
                    //                     g  //holds B data
                    //                 }
                    //           )
                    //           .SelectMany(
                    //              temp => temp.g.Take(1).DefaultIfEmpty(), //gets data and transfer to B
                    //              (A, B) =>
                    //                 new
                    //                 {
                    //                     Plant = B.Area.Company.Name,
                    //                     Area = B.Area.Name,
                    //                     B.Location,
                    //                     B.Code,
                    //                     Id = A.i.LocationEmergencyLightId,

                    //                     A.i.Battery,
                    //                     A.i.Bulb,
                    //                     A.i.Usable,
                    //                     A.i.Remarks,

                    //                     A.i.InspectedBy,
                    //                     A.i.ReviewedBy,
                    //                     A.i.NotedBy,
                    //                     A.i.CreatedAt,
                    //                     B.Area.CompanyId,
                    //                     HeaderId = A.i.EmergencyLightHeaderId
                    //                 }
                    //           );
                    var v = db.EmergencyLightDetails
                    .Where(a => a.EmergencyLightHeaders.Status == "Active")
                    .Where(a => a.EmergencyLightHeaderId == rptVM.ReferenceId)//A
                    .GroupJoin(
                            db.LocationEmergencyLights // B
                            .Where(a => a.Status == "Active"),
                            i => i.EmergencyLightHeaders.LocationEmergencyLightId, //A key
                            p => p.Id,//B key
                            (i, g) =>
                                new
                                {
                                    i, //holds A data
                                    g  //holds B data
                                }
                            )
                            .SelectMany(
                            temp => temp.g.DefaultIfEmpty(), //gets data and transfer to B
                            (A, B) =>
                                 new
                                 {

                                     id = A.i.ItemId,
                                     ItemName = A.i.Items.Name,
                                     A.i.Battery,
                                     A.i.Bulb,
                                     A.i.Usable,
                                     A.i.Remarks,
                                     A.i.Items.Code,
                                     A.i.InspectedBy,
                                     A.i.ReviewedBy,
                                     A.i.NotedBy,
                                     B.Location,
                                     CompanyName = B.Areas.Companies.Name,
                                     HeaderId = A.i.EmergencyLightHeaderId,

                                     Plant = B.Areas.Companies.Name,
                                     CompanyId = B.Areas.Companies.ID,
                                     Area = B.Areas.Name,
                                     A.i.CreatedAt,
                                 }
                            );
                    //if (rptVM.fromDate != def)
                    //{
                    //    v = v.Where(a => a.CreatedAt >= rptVM.fromDate && a.CreatedAt <= rptVM.toDate);
                    //}
                    var lsts = v.OrderBy(a => a.ItemName).ToList();
                    DataTable dts = new DataTable();
                    dts = ToDataTable(lsts);
                    ReportDataSource datasources = new ReportDataSource("EmergencyLight", dts);
                    LocalReport.DataSources.Clear();
                    LocalReport.DataSources.Add(datasources);
                    return LocalReport.Render(rptVM.rptType);
                }
                else if (rptVM.Report == "rptInergenTank")
                {
                    //var v = db.InergenTankDetails
                    //.Where(a => a.InergenTankHeaderId == rptVM.ReferenceId)//A                                                 
                    //.GroupJoin(
                    //   db.LocationInergenTanks // B
                    //   .Where(a => a.Status == "Active"),
                    //   i => i.LocationInergenTankId, //A key
                    //   p => p.Id,//B key
                    //   (i, g) =>
                    //      new
                    //      {
                    //          i, //holds A data
                    //          g  //holds B data
                    //      }
                    //)
                    //.SelectMany(
                    //   temp => temp.g.Take(1).DefaultIfEmpty(), //gets data and transfer to B
                    //   (A, B) =>
                    //      new
                    //      {

                    //          Id = A.i.LocationInergenTankId,
                    //          Location = B.Area1.Name,

                    //          B.Area1.Code,

                    //          A.i.Cylinder,
                    //          A.i.Gauge,
                    //          A.i.Hose,
                    //          A.i.Pressure,
                    //          A.i.Remarks,


                    //          A.i.InspectedBy,
                    //          A.i.ReviewedBy,
                    //          A.i.NotedBy,
                    //          A.i.CreatedAt,
                    //          B.Serial,

                    //          B.Capacity,
                    //          B.Area,

                    //          EquipmentType = "INERGEN",
                    //          B.Area1.CompanyId,
                    //          CompanyName = B.Area1.Company.Name,
                    //          HeaderId = A.i.InergenTankHeaderId
                    //      }
                    //);

                    //if (rptVM.fromDate != def)
                    //{
                    //    v = v.Where(a => a.CreatedAt >= rptVM.fromDate && a.CreatedAt <= rptVM.toDate);
                    //}

                    var v = db.InergenTankDetails
                    .Where(a => a.InergenTankHeaders.Status == "Active")
                    .Where(a => a.InergenTankHeaderId == rptVM.ReferenceId)//A   
                    .GroupJoin(
                            db.LocationInergenTanks // B
                            .Where(a => a.Status == "Active"),
                            i => i.InergenTankHeaders.LocationInergenTankId, //A key
                            p => p.Id,//B key
                            (i, g) =>
                                new
                                {
                                    i, //holds A data
                                    g  //holds B data
                                }
                            )
                            .SelectMany(
                            temp => temp.g.DefaultIfEmpty(), //gets data and transfer to B
                            (A, B) =>
                                 new
                                 {

                                     id = A.i.ItemId,
                                     ItemName = A.i.Items.Name,
                                     A.i.Items.Code,
                                     A.i.Cylinder,

                                     A.i.Gauge,
                                     A.i.Pressure,
                                     A.i.Hose,
                                     A.i.Remarks,
                                     Location = B.Area,
                                     B.Serial,
                                     B.Capacity,
                                     A.i.InspectedBy,
                                     A.i.ReviewedBy,
                                     A.i.NotedBy,
                                     CompanyName = B.Areas.Companies.Name,
                                     HeaderId = A.i.InergenTankHeaderId,
                                     A.i.Items.EquipmentType,
                                     Plant = B.Areas.Companies.Name,
                                     CompanyId = B.Areas.Companies.ID,
                                     Area = B.Areas.Name,
                                     A.i.CreatedAt,

                                 }
                            );


                    var lsts = v.OrderBy(a => a.ItemName).ToList();
                    DataTable dts = new DataTable();
                    dts = ToDataTable(lsts);
                    ReportDataSource datasources = new ReportDataSource("InergenTank", dts);
                    LocalReport.DataSources.Clear();
                    LocalReport.DataSources.Add(datasources);
                    return LocalReport.Render(rptVM.rptType);
                }
                else if (rptVM.Report == "rptFireHydrant")
                {
                    //var v = db.FireHydrantDetails
                    // .Where(a => a.FireHydrantHeaderId == rptVM.ReferenceId)//A          
                    // //.Where(a => a.FireHydrantHeaderId == id) //A
                    //           .GroupJoin(
                    //              db.LocationFireHydrants // B
                    //              .Where(a => a.Status == "Active"),
                    //              i => i.LocationFireHydrantId, //A key
                    //              p => p.Id,//B key
                    //              (i, g) =>
                    //                 new
                    //                 {
                    //                     i, //holds A data
                    //                     g  //holds B data
                    //                 }
                    //           )
                    //           .SelectMany(
                    //              temp => temp.g.Take(1).DefaultIfEmpty(), //gets data and transfer to B
                    //              (A, B) =>
                    //                 new
                    //                 {

                    //                     Id = A.i.LocationFireHydrantId,

                    //                     A.i.GlassCabinet,
                    //                     A.i.Hanger,
                    //                     A.i.Hose15,
                    //                     A.i.Nozzle15,
                    //                     A.i.Hose25,
                    //                     A.i.Nozzle25,
                    //                     A.i.SpecialTools,

                    //                     A.i.Remarks,
                    //                     B.Location,
                    //                     B.Code,
                    //                     A.i.InspectedBy,
                    //                     A.i.ReviewedBy,
                    //                     A.i.NotedBy,

                    //                     CompanyName = B.Area.Company.Name,
                    //                     HeaderId = A.i.FireHydrantHeaderId,
                    //                     B.Area.CompanyId,
                    //                     A.i.CreatedAt

                    //                 }
                    //           );

                    //if (rptVM.fromDate != def)
                    //{
                    //    v = v.Where(a => a.CreatedAt >= rptVM.fromDate && a.CreatedAt <= rptVM.toDate);
                    //}

                    var v = db.FireHydrantDetails
                       .Where(a => a.FireHydrantHeaders.Status == "Active")
                       .Where(a => a.FireHydrantHeaderId == rptVM.ReferenceId)//A         
                       .GroupJoin(
                               db.LocationFireHydrants // B
                               .Where(a => a.Status == "Active"),
                               i => i.FireHydrantHeaders.LocationFireHydrantId, //A key
                               p => p.Id,//B key
                               (i, g) =>
                                   new
                                   {
                                       i, //holds A data
                                       g  //holds B data
                                   }
                               )
                               .SelectMany(
                               temp => temp.g.DefaultIfEmpty(), //gets data and transfer to B
                               (A, B) =>
                                    new
                                    {
                                        Id = A.i.ItemId,
                                        ItemName = A.i.Items.Name,
                                        A.i.Items.Code,
                                        A.i.GlassCabinet,
                                        A.i.Hanger,
                                        A.i.Hose15,
                                        A.i.Nozzle15,
                                        A.i.Hose25,
                                        A.i.Nozzle25,
                                        A.i.SpecialTools,
                                        A.i.InspectedBy,
                                        A.i.ReviewedBy,
                                        A.i.NotedBy,
                                        A.i.Remarks,
                                        CompanyName = B.Areas.Companies.Name,
                                        HeaderId = A.i.FireHydrantHeaderId,
                                        B.Location,

                                        Plant = B.Areas.Companies.Name,
                                        CompanyId = B.Areas.Companies.ID,
                                        Area = B.Areas.Name,
                                        A.i.CreatedAt,

                                    }
                               );


                    var lsts = v.OrderBy(a => a.ItemName).ToList();
                    DataTable dts = new DataTable();
                    dts = ToDataTable(lsts);
                    ReportDataSource datasources = new ReportDataSource("FireHydrant", dts);
                    LocalReport.DataSources.Clear();
                    LocalReport.DataSources.Add(datasources);
                    return LocalReport.Render(rptVM.rptType);
                }
                else if (rptVM.Report == "rptBicycle")
                {
                    var v = db.BicycleEntryDetails
                            .Where(a => a.BicycleEntryHeaderId == rptVM.ReferenceId)
                            .Select(a => new
                            {


                                a.BicycleEntryHeaders.Bicycles.NameOwner,
                                a.BicycleEntryHeaders.Bicycles.ContactNo,
                                a.BicycleEntryHeaders.Bicycles.BrandName,
                                InspectedDate = a.BicycleEntryHeaders.CreatedAt,
                                ExpiryDate = "",
                                a.BicycleEntryHeaders.Bicycles.IdentificationNo,

                                a.FrameSafe,
                                a.FrameUnSafe,
                                a.FrameRemarks,
                                a.FrontForkSafe,
                                a.FrontForkUnSafe,
                                a.FrontForkRemarks,
                                a.HandlebarSafe,
                                a.HandlebarUnSafe,
                                a.HandlebarRemarks,
                                a.SeatSafe,
                                a.SeatUnSafe,
                                a.SeatRemarks,
                                a.FrontRearSafe,
                                a.FrontRearUnSafe,
                                a.FrontRearRemarks,
                                a.BrakeSafe,
                                a.BrakeUnSafe,
                                a.BrakeRemarks,
                                a.CrankChainSafe,
                                a.CrankChainUnSafe,
                                a.CrankChainRemarks,
                                a.ChainSafe,
                                a.ChainUnSafe,
                                a.ChainRemarks,
                                a.InspectedBy,
                                a.NotedBy



                            })
                            .ToList();


                    DataTable dts = new DataTable();
                    dts = ToDataTable(v);
                    ReportDataSource datasources = new ReportDataSource("Bicycle", dts);
                    LocalReport.DataSources.Clear();
                    LocalReport.DataSources.Add(datasources);
                    return LocalReport.Render(rptVM.rptType);
                }
                else if (rptVM.Report == "rptItemHistory")
                {


                    var v =
                     db.LocationItemDetails

                            .Where(a => a.Status == "Active")
                            .Where(a => a.DateCreated >= rptVM.fromDate && a.DateCreated <= rptVM.toDate)

                            .Select(a => new
                            {
                                Location = a.Equipment == "FE" ? db.LocationFireExtinguishers.Where(b => b.Id == a.HeaderId).FirstOrDefault().Location :
                                               a.Equipment == "EL" ? db.LocationEmergencyLights.Where(b => b.Id == a.HeaderId).FirstOrDefault().Location :
                                               a.Equipment == "FH" ? db.LocationFireHydrants.Where(b => b.Id == a.HeaderId).FirstOrDefault().Location :
                                               db.LocationInergenTanks.Where(b => b.Id == a.HeaderId).FirstOrDefault().Area,
                                AreaId = a.Equipment == "FE" ? db.LocationFireExtinguishers.Where(b => b.Id == a.HeaderId).FirstOrDefault().AreaId :
                                               a.Equipment == "EL" ? db.LocationEmergencyLights.Where(b => b.Id == a.HeaderId).FirstOrDefault().AreaId :
                                               a.Equipment == "FH" ? db.LocationFireHydrants.Where(b => b.Id == a.HeaderId).FirstOrDefault().AreaId :
                                               db.LocationInergenTanks.Where(b => b.Id == a.HeaderId).FirstOrDefault().AreaId,
                                Area = a.Equipment == "FE" ? db.LocationFireExtinguishers.Where(b => b.Id == a.HeaderId).FirstOrDefault().Areas.Name :
                                               a.Equipment == "EL" ? db.LocationEmergencyLights.Where(b => b.Id == a.HeaderId).FirstOrDefault().Areas.Name :
                                               a.Equipment == "FH" ? db.LocationFireHydrants.Where(b => b.Id == a.HeaderId).FirstOrDefault().Areas.Name :
                                               db.LocationInergenTanks.Where(b => b.Id == a.HeaderId).FirstOrDefault().Area,
                                a.Items.EquipmentType,
                                a.Items.SerialNo,
                                Items = a.Items.Code + " - " + a.Items.Name,
                                TransferredDate = a.CreatedDate,
                                SafeKeepDate = a.Items.DatePurchased
                                    ,
                                a.CreatedDate
                                    ,
                                a.Status,
                                FromDate = rptVM.fromDate,
                                ToDate = rptVM.toDate

                            })
                            .Where(a => a.AreaId == rptVM.ReferenceId)
                            .ToList();


                    DataTable dts = new DataTable();
                    dts = ToDataTable(v);
                    ReportDataSource datasources = new ReportDataSource("ItemHistory", dts);
                    LocalReport.DataSources.Clear();
                    LocalReport.DataSources.Add(datasources);
                    return LocalReport.Render(rptVM.rptType);
                }
                else if (rptVM.Report == "rptItemInventory")
                {
                    DateTime? dt = new DateTime(1, 1, 0001);
                    var v =
                      db.Items
                      .GroupJoin(
                                     db.LocationItemDetails // B
                                     .Where(a => a.Status == "Active"),
                                     i => i.Id, //A key
                                     p => p.ItemId,//B key
                                     (i, g) =>
                                        new
                                        {
                                            i, //holds A data
                                            g  //holds B data
                                        }
                                  )
                                  .SelectMany(
                                     temp => temp.g.Take(1).DefaultIfEmpty(), //gets data and transfer to B
                                     (A, B) =>
                                        new
                                        {
                                            A.i.Code,
                                            ItemName = A.i.Name,
                                            A.i.SerialNo,
                                            DatePurchased = A.i.DatePurchased == null ? dt : A.i.DatePurchased,
                                            A.i.Warranty,
                                            A.i.ItemStatus,
                                            A.i.EquipmentType,
                                            Location = A.i.EquipmentType == "Fire Extinguisher" ? db.LocationFireExtinguishers.Where(b => b.Id == B.HeaderId).FirstOrDefault().Location :
                                                        A.i.EquipmentType == "Emergency Light" ? db.LocationEmergencyLights.Where(b => b.Id == B.HeaderId).FirstOrDefault().Location :
                                                        A.i.EquipmentType == "Fire Hydrant" ? db.LocationFireHydrants.Where(b => b.Id == B.HeaderId).FirstOrDefault().Location :
                                                        A.i.EquipmentType == "Inergen Tank" ? db.LocationInergenTanks.Where(b => b.Id == B.HeaderId).FirstOrDefault().Area :
                                                       "",
                                            Area = A.i.EquipmentType == "Fire Extinguisher" ? db.LocationFireExtinguishers.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId == null ? 0 : db.LocationFireExtinguishers.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId :
                                                        A.i.EquipmentType == "Emergency Light" ? db.LocationEmergencyLights.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId == null ? 0 : db.LocationEmergencyLights.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId :
                                                        A.i.EquipmentType == "Fire Hydrant" ? db.LocationFireHydrants.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId == null ? 0 : db.LocationFireHydrants.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId :
                                                        A.i.EquipmentType == "Inergen Tank" ? db.LocationInergenTanks.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId == null ? 0 : db.LocationInergenTanks.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId :
                                                       0



                                        }
                                  ).Where(a => a.Area == rptVM.ReferenceId).ToList();










                    DataTable dts = new DataTable();
                    dts = ToDataTable(v);
                    ReportDataSource datasources = new ReportDataSource("ItemInventory", dts);
                    LocalReport.DataSources.Clear();
                    LocalReport.DataSources.Add(datasources);
                    return LocalReport.Render(rptVM.rptType);
                }
                else
                {
                    return null;
                }






            }
            catch (Exception e)
            {
                this.WriteLog(e.InnerException.Message.ToString(), true);
                throw;
            }


        }


        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public void WriteLog(string text, bool append)
        {
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\logs.txt", append);
            sw.Write(text);
            sw.Close();
        }
    }


}

