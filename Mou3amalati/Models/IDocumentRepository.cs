using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public interface IDocumentRepository
    {
        Document GetDocument(int Id);
        IEnumerable<Document> GetAllDocuments();
        Task<Document> AddDocument(Document Document);
        Document Update(Document DocumentChanges);
        Document Delete(int Id);
    }
}
