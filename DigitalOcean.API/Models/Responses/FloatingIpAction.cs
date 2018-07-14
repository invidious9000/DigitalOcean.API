using System;
using System.Diagnostics.CodeAnalysis;

namespace DOcean.API.Models.Responses
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class FloatingIpAction
    {
        /// <summary>
        /// A unique numeric ID that can be used to identify and reference an action.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The current status of the action. This can be "in-progress", "completed", or "errored".
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// This is the type of action that the object represents. For example, this could be "assign_ip" to represent the state of a Floating IP assign action.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the action was initiated.
        /// </summary>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the action was completed.
        /// </summary>
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// A unique identifier for the resource that the action is associated with.
        /// </summary>
        public long ResourceId { get; set; }

        /// <summary>
        /// The type of resource that the action is associated with.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// A slug representing the region where the action occurred.
        /// </summary>
        public string RegionSlug { get; set; }
    }
}