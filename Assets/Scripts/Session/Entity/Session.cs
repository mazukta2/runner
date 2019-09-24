using UnityEngine;
using System.Collections;
using Game;

public class Session
{
    public CharacterData StartCharacter => _characterData;

    private WorldData _worldData;
    private CharacterData _characterData;

    public Session(WorldData worldData, CharacterData characterData)
    {
        this._worldData = worldData;
        this._characterData = characterData;
    }
}
