// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.AI.Language.Conversations.Models
{
    /// <summary> Represents a conversation analysis response. </summary>
    public partial class AnalyzeConversationResult
    {
        /// <summary> Initializes a new instance of AnalyzeConversationResult. </summary>
        /// <param name="query"> The conversation utterance given by the caller. </param>
        /// <param name="prediction"> The prediction result of a conversation project. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="query"/> or <paramref name="prediction"/> is null. </exception>
        internal AnalyzeConversationResult(string query, BasePrediction prediction)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            if (prediction == null)
            {
                throw new ArgumentNullException(nameof(prediction));
            }

            Query = query;
            Prediction = prediction;
        }

        /// <summary> Initializes a new instance of AnalyzeConversationResult. </summary>
        /// <param name="query"> The conversation utterance given by the caller. </param>
        /// <param name="detectedLanguage"> The system detected language for the query. </param>
        /// <param name="prediction"> The prediction result of a conversation project. </param>
        internal AnalyzeConversationResult(string query, string detectedLanguage, BasePrediction prediction)
        {
            Query = query;
            DetectedLanguage = detectedLanguage;
            Prediction = prediction;
        }

        /// <summary> The conversation utterance given by the caller. </summary>
        public string Query { get; }
        /// <summary> The system detected language for the query. </summary>
        public string DetectedLanguage { get; }
        /// <summary> The prediction result of a conversation project. </summary>
        public BasePrediction Prediction { get; }
    }
}
