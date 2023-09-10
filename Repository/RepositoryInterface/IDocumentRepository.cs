using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryInterface
{
    public interface IDocumentRepository<Document>
    {
        Document GetById(int id);
        IEnumerable<Document> GetAll();
        IEnumerable<Document> Find(Func<Document, bool> predicate);
        void Add(Document entity);
      
    }
}
