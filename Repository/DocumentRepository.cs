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
        public Document GetById(int id)
        {
            return dbContext.Documents.FirstOrDefault(doc => doc.ID == id);
        }

        public IEnumerable<Document> GetAll()
        {
            return dbContext.Documents.ToList();
        }

        public IEnumerable<Document> GetAllByUserId(int id)
        {
            return dbContext.Documents.ToList().Where(x=>x.UserID==id) == null ? new List<Document> () : dbContext.Documents.ToList().Where(x => x.UserID == id);
        }

        public IEnumerable<Document> Find(Func<Document, bool> predicate)
        {
            return dbContext.Documents.Where(predicate).ToList();
        }

        public void Add(Document document)
        {
            dbContext.Documents.Add(document);
            dbContext.SaveChanges();
        }
    }
}
