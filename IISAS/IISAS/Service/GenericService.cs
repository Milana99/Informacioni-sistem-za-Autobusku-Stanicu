using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Service
{
    abstract class GenericService<T> where T : class
    {
        protected Repository.GenericRepository<T> repository;

        public GenericService(Repository.GenericRepository<T> repository)
        {
            this.repository = repository;
        }

        public List<T> GetAll()
        {
            return repository.Load();
        }

        public T GetOne(int elementId)
        {
            Console.WriteLine("Element: ", elementId);
            return repository.Load().FirstOrDefault(element => returnId(element) == elementId);
        }

        public void CreateElement(T element)
        {
            repository.Add(element);
        }

        public void DeleteElement(int elementId)
        {
            T elementToDelete = GetOne(elementId);
            if (elementToDelete != null)
            {
                repository.Remove(elementToDelete);
            }
        }

        public void Update(T updatedElement)
        {
            repository.Update(updatedElement);
        }

        abstract public int returnId(T element);
    }
}