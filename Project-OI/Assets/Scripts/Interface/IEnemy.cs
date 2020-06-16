using System;

public interface IEnemy
{
    Action OnDeath { get; set; }
}
