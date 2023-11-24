using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;

namespace Master.IntegrationTest.Mocks
{
    public class MockService<T> where T : class
    {
        public Mock<DbSet<T>> ConfigMock(IQueryable<T> data)
        {
            var mockSet = new Mock<DbSet<T>>();

            if (data != null)
            {
                mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            }

            return mockSet;
        }
    }
}
