namespace YouniLab.Member.Application.AppServices
{
    public class MemberAppService
    {
        public async Task<bool> GetMemberAsync(Guid id)
        {
            Console.WriteLine(id);
            return true;
        }
    }
}
