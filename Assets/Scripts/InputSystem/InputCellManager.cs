using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.InputSystem
{
    public class InputCellManager : MonoBehaviour
    {
        private static List<InputCell> cells = new List<InputCell>();

        public static void AddCell(InputCell _inputCell)
        {
            cells.Add(_inputCell);
        }

        public static void SetAllCellText()
        {
            foreach (InputCell inputcell in cells)
            {
                switch (inputcell.type)
                {
                    case KeyType.Key:
                        inputcell.SetKeyText(InputManager.GetKeyCode(inputcell.keyName));
                        break;
                    case KeyType.ValueKey:
                        inputcell.SetKeyText(InputManager.GetValueKeyCode(inputcell.keyName));
                        break;
                    case KeyType.AxisPosKey:
                        inputcell.SetKeyText(InputManager.GetAxisPosKeyCode(inputcell.keyName));
                        break;
                    case KeyType.AxisNegKey:
                        inputcell.SetKeyText(InputManager.GetAxisNegKeyCode(inputcell.keyName));
                        break;
                    default:
                        break;
                }
            }
        }

    }
}