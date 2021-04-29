using System;
using System.ComponentModel.DataAnnotations;
using douell_p.GenericRepository;
using pdouelle.GenericController.Blob.Entities;

namespace pdouelle.GenericController.Blob.Models.Blobs.Entities
{
    public abstract class Blob : IEntity, IEntityBlob
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContainerName { get; set; }
    }
}