/*
 * Dictionaries are not visible in the inspector so 
 * this file contains serializable structs to be used
 * in lists to emulate visible dictionaries.
 * 
 */


using System;

[Serializable]
public struct stringToInt
{
    public string str;
    public int integer;
}