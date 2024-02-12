using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;

namespace EOXAdvisor
{
    public class ReportGenerator
    {
        private static string FormatDate(string inputDate)
        {
            if(inputDate == "")
            {
                return "";
            }
            DateTime date = DateTime.Parse(inputDate);

            string outputDate = date.ToString("MMMM dd, yyyy");

            return outputDate;
        }

        public static string CreateEOXByPIDReport(APIResponseObjects.PID.EOXByRecord EOXRecordsPID)
        {
            List<string> deDup = new List<string>();

            // will sometimes receive variations of the same EOX bulletin, so dump the extras
            for(int x=0; x < EOXRecordsPID.EOXRecord.Count;)
            {
                if(!deDup.Contains(EOXRecordsPID.EOXRecord[x].EOXInputValue))
                {
                    deDup.Add(EOXRecordsPID.EOXRecord[x].EOXInputValue);
                    x++;
                }
                else
                {
                    EOXRecordsPID.EOXRecord.Remove(EOXRecordsPID.EOXRecord[x]);
                }
            }

            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                // Report Title
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "ReportTitle");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.Write("Lifecycle Details");
                writer.RenderEndTag();

                writer.RenderEndTag(); // end row

                writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                // Note
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "ReportNote");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.Write("NOTE: The Cisco provided 'Suggested Replacement' may or may not be appropriate for a customer's environment.");
                writer.RenderEndTag();

                writer.RenderEndTag(); // end row

                writer.AddAttribute(HtmlTextWriterAttribute.Class, "BlankRow");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.RenderEndTag();

                writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                // Policy Link
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.Write("Cisco's EOL Policy: ");
                writer.RenderEndTag();

                writer.AddAttribute(HtmlTextWriterAttribute.Class, "URLFormat");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                writer.AddAttribute(HtmlTextWriterAttribute.Href, "https://www.cisco.com/c/en/us/products/eos-eol-policy.html");
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.Write("https://www.cisco.com/c/en/us/products/eos-eol-policy.html");
                writer.RenderEndTag();
                writer.RenderEndTag();

                writer.RenderEndTag(); // end row

                foreach (var record in EOXRecordsPID.EOXRecord)
                {
                    if (record.EOLProductID != "")
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // PID
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "HeaderLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(record.EOLProductID);
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // Product Description
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("Product: ");
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(record.ProductIDDescription);
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // URL
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("Bulletin URL: ");
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "URLFormat");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        writer.AddAttribute(HtmlTextWriterAttribute.Href, record.LinkToProductBulletinURL);
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write(record.LinkToProductBulletinURL);
                        writer.RenderEndTag();
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "BlankRow");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // Life
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("End of Life: ");
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(FormatDate(record.EOXExternalAnnouncementDate.Value));
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // Sale
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("End of Sale: ");
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(FormatDate(record.EndOfSaleDate.Value));
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // Support
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("End of HW Support: ");
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(FormatDate(record.LastDateOfSupport.Value));
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "BlankRow");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // SW Maintenance
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("End of SW Maint Releases: ");
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(FormatDate(record.EndOfSWMaintenanceReleases.Value));
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "BlankRow");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // Security Vulnerability
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("End of Security Fixes: ");
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(FormatDate(record.EndOfSecurityVulSupportDate.Value));
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "BlankRow");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // New Service
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("End of New Service Attach:");
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(FormatDate(record.EndOfSvcAttachDate.Value));
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "BlankRow");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // SmartNET Renewal
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("End of Service Contract Renewal:");
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(FormatDate(record.EndOfServiceContractRenewal.Value));
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "BlankRow");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // Migration PID
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("Suggested Replacement: ");
                        writer.RenderEndTag();

                        if (record.EOXMigrationDetails.MigrationProductId != "")
                        {
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                            writer.RenderBeginTag(HtmlTextWriterTag.Div);
                            writer.Write(record.EOXMigrationDetails.MigrationProductId + " (" +
                                record.EOXMigrationDetails.MigrationInformation + ")");
                            writer.RenderEndTag();
                        }
                        else
                        {
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                            writer.RenderBeginTag(HtmlTextWriterTag.Div);
                            writer.Write("no suggested replacement / review the bulletin URL above");
                            writer.RenderEndTag();
                        }

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "BlankRow");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // URL
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("Replacement URL: ");
                        writer.RenderEndTag();

                        if (record.EOXMigrationDetails.MigrationProductInfoURL != "")
                        {
                            writer.AddAttribute(HtmlTextWriterAttribute.Href, record.EOXMigrationDetails.MigrationProductInfoURL);
                            writer.RenderBeginTag(HtmlTextWriterTag.A);
                            writer.Write(record.EOXMigrationDetails.MigrationProductInfoURL);
                            writer.RenderEndTag();
                        } else
                        {
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                            writer.RenderBeginTag(HtmlTextWriterTag.Div);
                            writer.Write("no link provided / review the bulletin URL above");
                            writer.RenderEndTag();
                        }

                        writer.RenderEndTag(); // close row

                        // Blanks
                        writer.RenderBeginTag(HtmlTextWriterTag.P);
                        writer.RenderEndTag();
                        writer.RenderBeginTag(HtmlTextWriterTag.P);
                        writer.RenderEndTag();
                    }
                    // no EOL bulletin or a bogus PID (Cisco API response doesn't differentiate)
                    else if(record.EOLProductID == "" && record.EOXInputValue !="")
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // Input PID
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "HeaderLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(record.EOXInputValue);
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "RowContainer"); // start row
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // No EOX Published
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralLabel");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("EOX Status: ");
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "GeneralData");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write("no EOL bulletin found for this PID (are you sure the PID is valid?)");
                        writer.RenderEndTag();

                        writer.RenderEndTag(); // close row
                    }
                }
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "BlankRow");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.RenderEndTag();

                writer.AddAttribute(HtmlTextWriterAttribute.Class, "BlankRow");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.RenderEndTag();
            }

            return stringWriter.ToString();
        }
    }
}