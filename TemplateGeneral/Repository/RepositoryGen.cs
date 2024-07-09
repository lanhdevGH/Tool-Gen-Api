using DevExpress.Data.TreeList;
using DevExpress.Office.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.TemplateGeneral
{
    public static class RepositoryGen
    {
        public static string GenerateIRepositoryContent(string projectName, string nameRepoDir)
        {
            return $@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace {projectName}.{nameRepoDir}
{{
    public interface IRepository<T> where T : class
    {{
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }}
}}
            ";
        }

        public static string GenerateRepositoryImplContent(string projectName, string repoDirName, string implementDirName)
        {
            return $@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace {projectName}.{repoDirName}.{implementDirName}
{{
    public class Repository<T> : IRepository<T> where T : class
    {{
        protected readonly <tmpDbContext> _dbContext;
        public Repository(<tmpDbContext> context)
        {{
            _dbContext = context;
        }}

        public async Task<IEnumerable<T>> GetAllAsync()
        {{
            return await _dbContext.Set<T>().ToListAsync();
        }}

        public async Task<T> GetByIdAsync(Guid id)
        {{
            return await _dbContext.Set<T>().FindAsync(id);
        }}

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {{
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }}

        public async Task AddAsync(T entity)
        {{
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }}

        public async Task DeleteAsync(T entity)
        {{
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }}

        public async Task UpdateAsync(T entity)
        {{
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }}
    }}
}}
            ";
        }

        public static string GenerateModelIRepositoryContent(string namespaceModel, string projectName, string repoDirName, string nameModel)
        {
            return $@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using {namespaceModel};

namespace {projectName}.{repoDirName}
{{
    public interface I{nameModel}Repository : IRepository<{nameModel}>
    {{
        // -- Tạo thêm những phương thức
    }}
}}
            ";
        }
    }
}
