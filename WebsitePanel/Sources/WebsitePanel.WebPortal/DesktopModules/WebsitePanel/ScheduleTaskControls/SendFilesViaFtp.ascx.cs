// Copyright (c) 2014, Outercurve Foundation.
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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WebsitePanel.EnterpriseServer;
using WebsitePanel.Portal.UserControls.ScheduleTaskView;

namespace WebsitePanel.Portal.ScheduleTaskControls
{
	public partial class SendFilesViaFtp : EmptyView
	{
		private static readonly string FilePathParameter = "FILE_PATH";
		private static readonly string ServerParameter = "FTP_SERVER";
		private static readonly string UserNameParameter = "FTP_USERNAME";
		private static readonly string PasswordParameter = "FTP_PASSWORD";
		private static readonly string RemoteFolderParameter = "FTP_FOLDER";

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Sets scheduler task parameters on view.
		/// </summary>
		/// <param name="parameters">Parameters list to be set on view.</param>
		public override void SetParameters(ScheduleTaskParameterInfo[] parameters)
		{
			base.SetParameters(parameters);

			this.SetParameter(this.txtFilePath, FilePathParameter);
			this.SetParameter(this.txtServer, ServerParameter);
			this.SetParameter(this.txtUserName, UserNameParameter);
			this.SetParameter(this.txtPassword, PasswordParameter);
			this.SetParameter(this.txtRemoteFolder, RemoteFolderParameter);
		}

		/// <summary>
		/// Gets scheduler task parameters from view.
		/// </summary>
		/// <returns>Parameters list filled  from view.</returns>
		public override ScheduleTaskParameterInfo[] GetParameters()
		{
			ScheduleTaskParameterInfo filePath = this.GetParameter(this.txtFilePath, FilePathParameter);
			ScheduleTaskParameterInfo server = this.GetParameter(this.txtServer, ServerParameter);
			ScheduleTaskParameterInfo userName = this.GetParameter(this.txtUserName, UserNameParameter);
			ScheduleTaskParameterInfo password = this.GetParameter(this.txtPassword, PasswordParameter);
			ScheduleTaskParameterInfo remoteFolder = this.GetParameter(this.txtRemoteFolder, RemoteFolderParameter);

			return new ScheduleTaskParameterInfo[5] { filePath, server, userName, password, remoteFolder };
		}
	}
}