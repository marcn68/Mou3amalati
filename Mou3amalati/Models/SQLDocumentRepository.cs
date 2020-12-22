using Microsoft.EntityFrameworkCore;
using Mou3amalati.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class SQLDocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IRoleRepository roleRepository;

        public SQLDocumentRepository(ApplicationDbContext context, IRoleRepository roleRepository)
        {
            this.context = context;
            this.roleRepository = roleRepository;
        }
        public async Task<Document> AddDocument(Document Document)
        {
            for(var i = 0; i< Document.Steps; i++)
            {
                var workflow = new WorkFlow
                {
                    OrdinalPosition = i + 1,
                    RoleId = await roleRepository.getRoleIdByName("Citizen")
                    
                };
                Document.WorkFlows.Add(workflow);
            }
            context.Documents.Add(Document);
            context.SaveChanges();
            return Document;
        }

        public Document Delete(int Id)
        {
            var document = context.Documents.Find(Id);
            if (document != null)
            {
                context.Documents.Remove(document);
                context.SaveChanges();
            }
            return document;
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            return context.Documents;
        }

        public Document GetDocument(int Id)
        {
            return context.Documents
                .Include(d => d.WorkFlows)
                .FirstOrDefault(d => d.Id == Id);
        }

        public Document Update(Document DocumentChanges)
        {
            /*var document = context.Documents.Attach(DocumentChanges);
            document.State = Microsoft.EntityFrameworkCore.EntityState.Modified;*/
            context.Documents.Update(DocumentChanges);
            context.SaveChanges();
            return DocumentChanges;
        }
    }
}
