namespace backend1.Data.Repository
{
    public class ChildrenWithCourageAppRepository
    {
        private ChildrenWithCourageDBContext _dbContext;
        public ChildrenWithCourageAppRepository(ChildrenWithCourageDBContext childrenDBContext)
        {
            _dbContext = childrenDBContext;
        }
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
