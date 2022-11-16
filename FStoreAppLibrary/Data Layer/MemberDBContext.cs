using FStoreAppLibrary.Models;

namespace FStoreAppLibrary.Data_Layer
{
    public class MemberDBContext
    {
        private static MemberDBContext instance = null;
        private static readonly object instanceLock =  new object();
        private MemberDBContext() { }

        public static MemberDBContext Instance  {
            get{
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new MemberDBContext();
                    }
                    return instance;
                }
            }
        }

        public List<Member> GetMembers()
        {   
            using (FStoreContext fStoreContext = new FStoreContext())
            {
                return fStoreContext.Members.ToList();
            }
        }

        public Member GetMemberById(int memberId)
        {
            using (FStoreContext fStoreContext = new FStoreContext())
            {
                Member member = fStoreContext.Members.Find(memberId);
                return member;
            }          
        }

       public Boolean Delete(int memberId) {
            Member member = GetMemberById(memberId);

            if (member != null)
            {
                using (FStoreContext fStoreContext = new FStoreContext())
                {
                    fStoreContext.Members.Remove(member);
                    fStoreContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public Boolean Update(Member member)
        {
            Member member1 = GetMemberById(member.MemberId);

            if (member1 != null)
            {
                using (FStoreContext fStoreContext = new FStoreContext())
                {
                    fStoreContext.Members.Attach(member);
                    fStoreContext.Entry(member).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    fStoreContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
       
        public Boolean Insert(Member member)
        {
            Member member1 = GetMemberById(member.MemberId);
            
            if (member1 == null)
            {
                using (FStoreContext fStoreContext = new FStoreContext())
                {
                    fStoreContext.Members.Attach(member);
                    fStoreContext.Members.Add(member);
                    fStoreContext.SaveChanges();
                    return true;                
                }
            }
            return false;
        }

        public Member Exist(string email, string password)
        {
            Member member = null;
            using (FStoreContext fStoreContext = new FStoreContext())
            {
                member = fStoreContext.Members.Where(m => m.Email == email && m.Password == password).SingleOrDefault(); 
            }
            return member;
        }
    }
}
