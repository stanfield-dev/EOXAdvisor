using System.Collections.Generic;

namespace EOXAdvisor
{
    public class InputParser
    {
        internal static string ParseTextboxInput(string inputString)
        {
            string queryString ="";
            int idxPID = 0;
            int idxCOMMA = 0;
            List<string> pidList = new List<string>();

            // parse a 'show inventory' dump
            while ((idxPID = inputString.IndexOf("PID:", idxPID)) != -1)
            {
                if((idxCOMMA = inputString.IndexOf(",", idxPID)) != -1)
                {
                    string tempString = inputString.Substring(idxPID, (idxCOMMA - idxPID + 1));
                    tempString = tempString.Remove(0, 4);
                    tempString = tempString.Trim(new char[] {' ', ','});

                    if(tempString.Length > 1)
                    {
                        if(!pidList.Contains(tempString) && tempString != "Unknown PID" && tempString != "N/A")
                        {
                            pidList.Add(tempString);
                        }
                    }

                    idxPID = idxCOMMA;
                } 
                else
                {
                    // garbage input
                    idxPID += 4;
                }
            }

            // if no 'PID:' strings found then maybe it's a comma delimited list of PIDs
            if(pidList.Count < 1)
            {
                inputString.Trim(new char[] {' '});

                string[] tempPIDSArray = inputString.Split(',');

                foreach(var foo in tempPIDSArray)
                {
                    if (!pidList.Contains(foo))
                    {
                        pidList.Add(foo);
                    }
                }
            }

            // send back the list of PIDs or null
            if(pidList.Count < 1)
            {
                return queryString;
            }
            else
            {
                foreach(var pid in pidList)
                {
                    queryString += pid + ",";
                }
                return queryString.TrimEnd(',');
            }
        }
    }
}
