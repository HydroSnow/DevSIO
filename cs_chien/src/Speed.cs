using System.Collections.Generic;

namespace cs_chien
{
    abstract class Speed
    {
        private static Dictionary<Model, float> speedX = new Dictionary<Model, float>();
        private static Dictionary<Model, float> speedY = new Dictionary<Model, float>();

        public static void Gravity(Model model)
        {
            SetY(model, GetY(model) + 0.5f);
        }

        public static void TickSpeed(Model model)
        {
            model.MoveX(GetX(model));
            model.MoveY(GetY(model));
        }

        public static float GetX(Model model)
        {
            try
            {
                return speedX[model];
            }
            catch (KeyNotFoundException)
            {
                speedX[model] = 0;
                return 0;
            }
        }

        public static void SetX(Model model, float speed)
        {
            speedX[model] = speed;
        }

        public static float GetY(Model model)
        {
            try
            {
                return speedY[model];
            }
            catch (KeyNotFoundException)
            {
                speedY[model] = 0;
                return 0;
            }
        }

        public static void SetY(Model model, float speed)
        {
            speedY[model] = speed;
        }
    }
}
