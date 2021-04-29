using System.Reflection;

namespace pdouelle.GenericController.Blob
{
    public class GenericTypesForController
    {
        public TypeInfo Entity { get; set; }
        public TypeInfo Dto { get; set; }
        public TypeInfo BlobEntity { get; set; }
        public TypeInfo BlobDto { get; set; }
        public TypeInfo QueryList { get; set; }
        public TypeInfo QueryById { get; set; }
        public TypeInfo Create { get; set; }
        public TypeInfo Update { get; set; }
        public TypeInfo Patch { get; set; }
        public TypeInfo Delete { get; set; }
    }
}