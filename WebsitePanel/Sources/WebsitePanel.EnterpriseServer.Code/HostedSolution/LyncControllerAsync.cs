﻿// Copyright (c) 2014, Outercurve Foundation.
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
using System.Threading;
using System.Collections.Generic;
using System.Text;
using WebsitePanel.Providers;
using WebsitePanel.Providers.Common;
using WebsitePanel.Providers.HostedSolution;
using WebsitePanel.Providers.ResultObjects;
using WebsitePanel.Providers.Lync;
using WebsitePanel.EnterpriseServer.Code.HostedSolution;


namespace WebsitePanel.EnterpriseServer.Code.HostedSolution
{
    public class LyncControllerAsync
    {
        private int lyncServiceId;
        private int organizationServiceId;

        public int LyncServiceId
        {
            get { return this.lyncServiceId; }
            set { this.lyncServiceId = value; }
        }

        public int OrganizationServiceId
        {
            get { return this.organizationServiceId; }
            set { this.organizationServiceId = value; }
        }


        public void Enable_CsComputerAsync()
        {
            // start asynchronously
            Thread t = new Thread(new ThreadStart(Enable_CsComputer));
            t.Start();
        }

        private void Enable_CsComputer()
        {
            int[] lyncServiceIds;

            LyncController.GetLyncServices(lyncServiceId, out lyncServiceIds);

            foreach (int id in lyncServiceIds)
            {
                LyncServer lync = null;
                try
                {
                    lync = LyncController.GetLyncServer(id, organizationServiceId);
                    if (lync != null)
                    {
                        lync.ReloadConfiguration();
                    }
                }
                catch (Exception exe)
                {
                    TaskManager.WriteError(exe);
                    continue;
                }
            }


        }


    }
}