// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> JIT approver definition. </summary>
    public partial class JitApproverDefinition : WritableSubResource
    {
        /// <summary> Initializes a new instance of JitApproverDefinition. </summary>
        public JitApproverDefinition()
        {
        }

        /// <summary> Initializes a new instance of JitApproverDefinition. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="type"> The approver type. </param>
        /// <param name="displayName"> The approver display name. </param>
        internal JitApproverDefinition(string id, JitApproverType? type, string displayName) : base(id)
        {
            Type = type;
            DisplayName = displayName;
        }

        /// <summary> The approver type. </summary>
        public JitApproverType? Type { get; set; }
        /// <summary> The approver display name. </summary>
        public string DisplayName { get; set; }
    }
}
