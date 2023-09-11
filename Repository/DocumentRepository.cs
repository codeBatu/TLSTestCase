using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Models;
using Repository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DocumentRepository : IDocumentRepository<Document>
    {
        private readonly TestCaseContext dbContext;

        public DocumentRepository(TestCaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // Documenti id ye gore getirir
        public Document GetById(int id)
        {
            return dbContext.Documents.FirstOrDefault(doc => doc.ID == id);
        }
        // Tum documentleri getirir

        public IEnumerable<Document> GetAll()
        {
            return dbContext.Documents.ToList();
        }

        // Userin id sine gore documentleri getirir
        public IEnumerable<Document> GetAllByUserId(int id)
        {
            return dbContext.Documents.ToList().Where(x=>x.UserID==id) == null ? new List<Document> () : dbContext.Documents.ToList().Where(x => x.UserID == id);
        }
        // Documenti id ye gore getirir

        public IEnumerable<Document> Find(Func<Document, bool> predicate)
        {
            return dbContext.Documents.Where(predicate).ToList();
        }

        // Documenti ekler
        public void Add(Document document)
        {
            dbContext.Documents.Add(document);
            
            dbContext.SaveChanges();
        }
    }
}
