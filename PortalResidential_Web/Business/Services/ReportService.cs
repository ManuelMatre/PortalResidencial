using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;
using PortalResidential_Web.Models.BindingModels;
using System.IO;
using System.Data;

namespace PortalResidential_Web.Business.Services
{
    public class ReportService
    {
        public FileParams CreatePdf(string reportName, List<AppUserBindingModel> objtList, ReportParameter[] reportParameters = null)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Files/Reports"), reportName);
            if (!System.IO.File.Exists(path))
                return null;
            lr.ReportPath = path;

            ReportDataSource rd = new ReportDataSource("DSResident", objtList);
            lr.DataSources.Add(rd);

            if (reportParameters != null)
                lr.SetParameters(reportParameters);

            string[] streams;
            string encoding, fileNameExtension, mimeType;
            Warning[] warnings;

            FileParams fileParams = new FileParams();
            fileParams.reportType = "Pdf";
            fileParams.renderedBytes = lr.Render(fileParams.reportType, fileParams.deviceInfo,
            out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            fileParams.mimeType = mimeType;
            return fileParams;
        }
    }
    public class FileParams
    {
        public byte[] renderedBytes { get; set; }
        public string mimeType { get; set; }
        public string deviceInfo { get; set; }
        public string reportType { get; set; }
        public string[] streams { get; set; }
        public string encoding { get; set; }
        public string fileNameExtension { get; set; }
        public Warning[] warnings { get; set; }
    }
}