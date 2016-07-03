/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the  Apache License, Version 2.0, please send an email to 
 * dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 *
 * ***************************************************************************/using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle ("ExaScript")]
[assembly: AssemblyDescription("ExaScript Runtime Library")]
[assembly: AssemblyConfiguration (BuildInfo.Configuration)]
[assembly: AssemblyProduct ("ExaScript")]
[assembly: AssemblyTrademark ("")]
[assembly: AssemblyCulture ("")]
// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible (false)]
// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid ("8513ba89-ec90-4410-a9c9-8b4e2b4c2838")]
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: NeutralResourcesLanguage ("en-US")]
[assembly: SecurityTransparent]
[assembly: CLSCompliant (false)]
#if FEATURE_SECURITY_RULES
[assembly: SecurityRules(SecurityRuleSet.Level1)]
[assembly: AssemblyCompany("ExaPhaser Industries")]
[assembly: AssemblyCopyright("(c) ExaPhaser Industries, 2015-2016")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
#endif
