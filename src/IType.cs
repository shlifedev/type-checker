using System.Collections.Generic;

namespace CAH.TypeChecker
{
    public interface IType
    {
    }

    /// <summary>
    ///     대부분 리플렉션을 해야하는 데이터 특성상 object로 처리하기 때문에
    ///     T 입력 자체는 사실 아무런 의미가 없지만 사용자의 UGS API 사용경험을 향상시켜 주기 위함.
    ///     나중에 제네릭 관련 코드를 모드 object로 변경해도 되지만
    ///     임시로 냅두고 DeclareType을 따로선언해서 처리
    ///     -> 어차피 이 타입들에 대한 값은 코드제네레이터에서 관리할 것 이기 때문에 별 의미 없을듯
    ///     <typeparam name="T"></typeparam>
    public interface IType<T> : IType
    {
        /// <summary>
        ///     All Type Names Auto Convert To Lower. (Int => int), (iNT => int)
        /// </summary>
        List<string> TypeDeclarations { get; }

        T Read(string value);

        string Write(T value);
    }
}