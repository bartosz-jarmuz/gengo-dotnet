﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Winterday.External.Gengo.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Winterday.External.Gengo.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot submit jobs without at least one valid job..
        /// </summary>
        internal static string AtLeastOneJobRequired {
            get {
                return ResourceManager.GetString("AtLeastOneJobRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Callback URL must be absolute.
        /// </summary>
        internal static string CallbackUrlMustBeAbsolute {
            get {
                return ResourceManager.GetString("CallbackUrlMustBeAbsolute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid job, type is File but identifier is not specified..
        /// </summary>
        internal static string FileButIdNotSpecified {
            get {
                return ResourceManager.GetString("FileButIdNotSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid job, tier value is invalid..
        /// </summary>
        internal static string InvalidTier {
            get {
                return ResourceManager.GetString("InvalidTier", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid job, type value is invalid..
        /// </summary>
        internal static string InvalidType {
            get {
                return ResourceManager.GetString("InvalidType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more of the jobs were already submitted..
        /// </summary>
        internal static string JobIsAlreadySubmitted {
            get {
                return ResourceManager.GetString("JobIsAlreadySubmitted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot modify value, job is read-only..
        /// </summary>
        internal static string JobIsReadOnly {
            get {
                return ResourceManager.GetString("JobIsReadOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid job, missing body value..
        /// </summary>
        internal static string MissingBody {
            get {
                return ResourceManager.GetString("MissingBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid job, missing slug value..
        /// </summary>
        internal static string MissingSlug {
            get {
                return ResourceManager.GetString("MissingSlug", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid job, missing source language code..
        /// </summary>
        internal static string MissingSourceLang {
            get {
                return ResourceManager.GetString("MissingSourceLang", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid job, missing target language code..
        /// </summary>
        internal static string MissingTargetLang {
            get {
                return ResourceManager.GetString("MissingTargetLang", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid job, type is Text but identifier is specified..
        /// </summary>
        internal static string TextButIdSpecified {
            get {
                return ResourceManager.GetString("TextButIdSpecified", resourceCulture);
            }
        }
    }
}
