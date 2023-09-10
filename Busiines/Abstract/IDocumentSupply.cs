using Model;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busiines.Abstract
{
    public interface IDocumentSupply
    {
        Document GetById(int id);
        IEnumerable<Document> GetAll();
        IEnumerable<Document> Find(Func<Document, bool> predicate);
        void Add(Document entity);


    }
}
