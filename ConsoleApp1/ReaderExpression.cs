using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ReaderExpression
    {
        List<Class4> list = new List<Class4>();
        public void exp<T>(LambdaExpression left, Operand? operand,  LambdaExpression right)
        {
                if (left != null && (left.Body.NodeType == ExpressionType.AndAlso || left.Body.NodeType == ExpressionType.OrElse))
                    readerExpression<T>(left as Expression<Func<T, bool>>);
                if (right != null && (right.Body.NodeType == ExpressionType.AndAlso || right.Body.NodeType == ExpressionType.OrElse))
                    readerExpression<T>(right as Expression < Func<T, bool> >);
           

        }
        public void readerExpression<T>(Expression<Func<T,bool>>expression)
        {
            MemberExpression member;
            ConstantExpression constant;
            Expression left, right;
            switch (expression.Body.NodeType)
            {
                case ExpressionType.AndAlso:
                    BinaryExpression be = expression.Body as BinaryExpression;

                    Class4 class4 = new Class4();
                    if (be != null)
                    {
                        class4.left = be.Left as LambdaExpression;
                        class4.operand = Operand.And;
                        class4.right = be.Right as LambdaExpression;
                    }
                    list.Add(class4);
                    exp<T>(class4.left as Expression<Func<T, bool>>, class4.operand, class4.right as Expression<Func<T, bool>>);
                    break;
                
                //case ExpressionType.Equal:
                //    BinaryExpression binary = expression.Body as BinaryExpression;

                //    if (binary != null)
                //    {
                //        member = binary.Left as MemberExpression;
                //        constant = binary.Right as ConstantExpression;
                //    }
                //    break;
                
                case ExpressionType.OrElse:
                    BinaryExpression binaryExpression = expression.Body as BinaryExpression;
                    Class4 class1 = new Class4();
                    if(binaryExpression != null)
                    {
                        class1.left = binaryExpression.Left as LambdaExpression;
                        class1.operand = Operand.And;
                        class1.right = binaryExpression.Right as LambdaExpression;
                    }
                    list.Add(class1);
                    LambdaExpression lambdaExpression1 = class1.left as LambdaExpression;
                    exp<T>(class1.left as LambdaExpression, class1.operand, class1.right as Expression<Func<T, bool>>);
                    break;
                
            }
        }
    }
}
