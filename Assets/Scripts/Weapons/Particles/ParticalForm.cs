using UnityEngine;

public class ParticalForm : MonoBehaviour
{
    public Form_type Type;
    public float Reload { get; private set; }

    public enum Form_type
    {
        Simple_Bullet, Ray, Rocket, Wave_In_Front, Wave_Around, Short_Wave_In_Front, Cone, Clot, Explozion_Clot, Mine, Fraction
    }

    public float CreateParticalStats(GameObject particle)
    {
        if( Type == Form_type.Simple_Bullet) // ������� ��������� �������
        {
            ChangeForm(particle, 1, 1);
            Reload = 0.2f;
            return 1f;

        }
        else if( Type == Form_type.Ray) // ���
        {
            ChangeForm(particle, 3, 1);
            Reload = 0f;
            return 0.05f;
        }
        else if ( Type == Form_type.Rocket) // ������
        {
            ChangeForm(particle, 2, 2);
            return 1f;
        }
        else if ( Type == Form_type.Wave_In_Front) // ����� ����� ����������
        {
            return 1f;
        }
        else if (Type == Form_type.Wave_Around) // ����� ������ ���������
        {
            return 1f;
        }
        else if (Type == Form_type.Short_Wave_In_Front) // �������� ����� �����
        {
            return 1f;
        }
        else if (Type == Form_type.Cone) // �����
        {
            return 1f;
        }
        else if (Type == Form_type.Clot) // �������
        {
            return 1f;
        }
        else if (Type == Form_type.Explozion_Clot) // �������� �������
        {
            return 1f;
        }
        else if (Type == Form_type.Mine) // ����
        {
            return 1f;
        }
        else if (Type == Form_type.Fraction) // �����
        {
            return 1f;
        }
        return 0f;
    }

    void ChangeForm(GameObject formToChange, float scaleX, float scaleY)
    {
        var form = new Vector2();
        form.x = formToChange.transform.localScale.x * scaleX;
        form.y = formToChange.transform.localScale.y * scaleY;
        formToChange.transform.localScale = form;
    }
}
