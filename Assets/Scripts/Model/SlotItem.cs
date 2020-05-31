using UnityEngine;

public class SlotItem
{
    public enum Type
    {
        NONE,
        MAIN_MENU,
        SAY,
        EQUIPMENT,
        ITEMS,
        CHAR_INFO,
        STATS,
        SKILLS,
        QUEST,
        MENU,
        QUICK_SLOTS,
        PICKUP,
        SIT,
        ATTACK,
        JUMP,
        INTERACT,
        SOUL_WEAPON,
        WORLD_MAP,
        MINIMAP,
        KEY_BINDING,
        MONSTER_BOOK,
        EXPRESSION
    }
    public Type SlotType { get; set; }
    public Sprite SlotSprite { get; set; }

    public SlotItem(Sprite sprite, Type type)
    {
        SlotSprite = sprite;
        SlotType = type;
    }
}




