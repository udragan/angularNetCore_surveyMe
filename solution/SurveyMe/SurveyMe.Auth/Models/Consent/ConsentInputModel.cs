// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
// Namespace changed

using System.Collections.Generic;

namespace udragan.netCore.SurveyMe.Auth.Models.Consent
{
	public class ConsentInputModel
	{
		public string Button { get; set; }
		public IEnumerable<string> ScopesConsented { get; set; }
		public bool RememberConsent { get; set; }
		public string ReturnUrl { get; set; }
	}
}
