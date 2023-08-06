namespace Practice.Random;

public interface IRandomNumber
{
    int GetHttpRandomNumber(int minNumber, int maxNumber);

    int GetNetRandomNumber(int minNumber, int maxNumber);
}