using AutoMapper;
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
        private readonly IMapper _mapper;

        public DocumentManager(IDocumentRepository<Document> context , IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }
        public void Add(DocumentDTO entity)
        {
            var ocument = _mapper.Map<Document>(entity);
            _context.Add(ocument);

       
        }

        public IEnumerable<Document> Find(Func<Document, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAllById(int UserId)
        {
           var documents = _context.GetAll().Where(x => x.UserID == UserId);
            return documents;

        }

        public Document GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
