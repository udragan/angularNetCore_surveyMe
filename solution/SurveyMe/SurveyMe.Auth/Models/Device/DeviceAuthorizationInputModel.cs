// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
// Namespace changed

using udragan.netCore.SurveyMe.Auth.Models.Consent;

namespace udragan.netCore.SurveyMe.Auth.Models.Device
{
	public class DeviceAuthorizationInputModel : ConsentInputModel
	{
		public string UserCode { get; set; }
	}
}
