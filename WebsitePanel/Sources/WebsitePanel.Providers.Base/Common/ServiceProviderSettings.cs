// Copyright (c) 2012, Outercurve Foundation.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
// - Redistributions of source code must  retain  the  above copyright notice, this
//   list of conditions and the following disclaimer.
//
// - Redistributions in binary form  must  reproduce the  above  copyright  notice,
//   this list of conditions  and  the  following  disclaimer in  the documentation
//   and/or other materials provided with the distribution.
//
// - Neither  the  name  of  the  Outercurve Foundation  nor   the   names  of  its
//   contributors may be used to endorse or  promote  products  derived  from  this
//   software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING,  BUT  NOT  LIMITED TO, THE IMPLIED
// WARRANTIES  OF  MERCHANTABILITY   AND  FITNESS  FOR  A  PARTICULAR  PURPOSE  ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL,  SPECIAL,  EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO,  PROCUREMENT  OF  SUBSTITUTE  GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)  HOWEVER  CAUSED AND ON
// ANY  THEORY  OF  LIABILITY,  WHETHER  IN  CONTRACT,  STRICT  LIABILITY,  OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE)  ARISING  IN  ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Specialized;
using System.Text;

namespace WebsitePanel.Providers
{
    public class ServiceProviderSettings
    {
        // settings hash
        StringDictionary hash = new StringDictionary();

        private int providerGroupID = 0;
        private string providerCode = "unknown";
        private string providerName = "Unknown";
        private string providerType = "";

        public ServiceProviderSettings()
        {
            // just do nothing
        }

        public ServiceProviderSettings(string[] settings)
        {
            // parse settings array
            foreach (string setting in settings)
            {
                int idx = setting.IndexOf('=');
                string key = setting.Substring(0, idx);
                string val = setting.Substring(idx + 1);

                if (key.StartsWith("Server:") ||
                    key.StartsWith("AD:"))
                    continue;

                if (key == "Provider:ProviderGroupID")
                    ProviderGroupID = Int32.Parse(val);
                else if (key == "Provider:ProviderCode")
                    ProviderCode = val;
                else if (key == "Provider:ProviderName")
                    ProviderName = val;
                else if (key == "Provider:ProviderType")
                    ProviderType = val;
                else
                    hash[key] = val;
            }
        }

        public string this[string settingName]
        {
            get
            {
                return hash[settingName];
            }
        }

        public int GetInt(string settingName)
        {
            int result;
            Int32.TryParse(hash[settingName], out result);
            return result;
        }

        public long GetLong(string settingName)
        {
            long result;
            Int64.TryParse(hash[settingName], out result);
            return result;
        }

        public bool GetBool(string settingName)
        {
            bool result;
            Boolean.TryParse(hash[settingName], out result);
            return result;
        }

        #region Public properties
        public int ProviderGroupID
        {
            get { return this.providerGroupID; }
            set { this.providerGroupID = value; }
        }

        public string ProviderCode
        {
            get { return this.providerCode; }
            set { this.providerCode = value; }
        }

        public string ProviderName
        {
            get { return this.providerName; }
            set { this.providerName = value; }
        }

        public string ProviderType
        {
            get { return this.providerType; }
            set { this.providerType = value; }
        }

        public StringDictionary Settings
        {
            get { return hash; }
        }
        #endregion
    }
}
