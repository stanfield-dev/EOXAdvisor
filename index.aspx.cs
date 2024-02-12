using System;

namespace EOXAdvisor
{
    public partial class index : System.Web.UI.Page
    {
        static string accessToken;
        protected async void Page_Load(object sender, EventArgs e)
        {
            if(accessToken == null)
            {
                accessToken = await Authenticator.Authenticate();
            }
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "Paste in 'show inventory' or a comma separated list of up to 20 PIDs..." &&
                TextBox1.Text.Length > 2)
            {
                string PIDS = InputParser.ParseTextboxInput(TextBox1.Text);

                if (PIDS != "")
                {
                    APIResponseObjects.PID.EOXByRecord EOXRecordsPID = await QueryAPI.GetEOXDetailsByPID<APIResponseObjects.PID.EOXByRecord>(accessToken, PIDS);

                    if (EOXRecordsPID != null)
                    {
                        Literal1.Text = ReportGenerator.CreateEOXByPIDReport(EOXRecordsPID);
                        form1.Visible = false;
                    }
                }
            }
        }
    }
}