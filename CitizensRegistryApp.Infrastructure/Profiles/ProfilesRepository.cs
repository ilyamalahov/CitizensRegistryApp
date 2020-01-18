using CitizensRegistryApp.Core.Data;
using CitizensRegistryApp.Core.Paging;
using CitizensRegistryApp.Core.Profiles;
using CitizensRegistryApp.Core.Profiles.Dto;
using Dapper;
using SqlKata;
using SqlKata.Compilers;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CitizensRegistryApp.Infrastructure.Profiles
{
    public class ProfilesRepository : IProfilesRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        private readonly SqlServerCompiler compiler;

        public ProfilesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;

            compiler = new SqlServerCompiler { UseLegacyPagination = false };
        }

        public async Task<PagingModel<ProfileDto>> GetProfiles(ProfileFilter filter, int page, int pageSize)
        {
            Query baseQuery = new Query().From("Profiles");

            if (filter != null)
            {
                baseQuery.WhereFilter(filter);
            }

            Query profilesQuery = baseQuery.Clone().Select("FirstName", "LastName", "MiddleName", "Birthday");

            profilesQuery.Offset((page - 1) * pageSize);

            profilesQuery.Limit(pageSize);

            Query totalQuery = baseQuery.Clone().AsCount("Id");

            SqlResult result = compiler.Compile(new Query[] { profilesQuery, totalQuery });

            using (IDbConnection connection = dbConnectionFactory.CreateConnection())
            {
                using (SqlMapper.GridReader reader = await connection.QueryMultipleAsync(result.Sql, result.NamedBindings))
                {
                    return new PagingModel<ProfileDto>
                    {
                        Items = await reader.ReadAsync<ProfileDto>(),
                        Total = await reader.ReadSingleAsync<int>()
                    };
                }
            }
        }
    }

    public static class QueryExtensions
    {
        public static Query WhereFilter(this Query query, Filter filter)
        {
            if(filter.Filters.Count() > 0)
            {
                // query = filter.Filters.Select(f => query.Where(f));

                // foreach (FilterBase subFilter in filter.Filters)
                // {
                    
                // }

                return query;
            }

            return query;
        }
    }
}
