using Busiines.Abstract;
using Model;
using Model.DTO;
using Repository;
using Repository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busiines.Concrete
{
    public class DocumentManager : IDocumentSupply
    {
        private readonly Repository.RepositoryInterface.IDocumentRepository<Document> _context;

        public DocumentManager(IDocumentRepository<Document> context)
        {
            _context = context;
        }
        public void Add(Document entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> Find(Func<Document, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAll()
        {
            throw new NotImplementedException();
        }

        public Document GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
