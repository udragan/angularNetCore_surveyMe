// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
// Namespace changed

namespace udragan.netCore.SurveyMe.Auth.Models.Consent
{
	public class ScopeViewModel
	{
		public string Name { get; set; }
		public string DisplayName { get; set; }
		public string Description { get; set; }
		public bool Emphasize { get; set; }
		public bool Required { get; set; }
		public bool Checked { get; set; }
	}
}
