using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    /// <summary>
    /// Represents the base class for all entities in the system.
    /// Provides common properties for auditing and entity management.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// This serves as the primary key in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// Automatically set to the current UTC date and time upon creation.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the ID of the user who created the entity.
        /// Nullable to account for scenarios where user linkage is optional.
        /// </summary>
        public string? CreatedById { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was last updated.
        /// Nullable to account for entities that have not been modified after creation.
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who last updated the entity.
        /// Nullable to account for scenarios where user linkage is optional or not applicable.
        /// </summary>
        public string? LastUpdatedById { get; set; }
    }
}
