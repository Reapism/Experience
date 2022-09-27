using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Maui.Graphics.Text;

namespace Sweaj.Experience.Bcl.Models
{
    public class ParameterNode
    {
        public string Name { get; }
    }

    public class ParameterNodeMetaData
    {
        
    }

    public abstract class ParameterNodeWeight
    {
        public decimal Quantity { get; }
        /// <summary>
        /// Returns all supported conversions between two unique ParameterNodeWeights by
        /// taking the Name as an identifier.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public abstract Func<string, ParameterNodeWeight> Convert(string )
    }

    public class ParameterNodeWeightResult
    {
        public string Name { get; }

    }

    public class ParameterNodeWeightLookup
    {
        public static IDictionary<string, ParameterNodeWeight>
        public ParameterNodeWeight Get(string name)
        {

        }
    }

    public class ExperienceException : Exception
    {
        public override Exception GetBaseException()
        {
            Exception currentException = this;
            while (InnerException is not null)
            {
                currentException = InnerException;
            }

            return currentException;
        }
    }

    public class TrainingException : ExperienceException
    {

    }

    public class TestingException : ExperienceException
    {

    }

    // All exception details should be interfaced like this as markers,
    // and the ExperienceExceptionLogger should look for all these interfaces
    // and attach their properties to decorate the log.
    //
    // Experience Exceptions will use these interfaces to add detail to the messages.
    public interface ISourced
    {
        public string Source { get; set; }

    }

    public interface IFriendlyErrorMessage
    {
        public string FriendlyErrorMessage { get; set; }
    }

    public interface ITagged
    {
        public string Tag { get; set; }
    }

    public sealed class UnsupportedParameterNodeWeightConversionException : TrainingException
    {

    }

    public sealed class UnsupportedVisitException : TrainingException
    {
        public UnsupportedVisitException(Type visitorType)
        {
            VisitorType = visitorType;
        }
        public Type VisitorType { get; }
    }

    /// <summary>
    /// Takes in a derived <see cref="ExperienceException"/>
    /// and visits each one and aggregating the exception
    /// details into a log-able exception.
    /// </summary>
    public sealed class ExperienceExceptionVisitor : IReturnableVisitor<ExperienceException, ExperienceException>
    {
        // represents a function to call during every iteration
        bool IReturnableVisitor<ExperienceException, ExperienceException>.CanVisit { get; set; }

        public ExperienceException Visit(ExperienceException exception)
        {
            var currentException = exception as Exception;
            while (exception?.InnerException is not null)
            {
                currentException = currentException.InnerException;
                if (currentException.InnerException is not ExperienceException)
                {
                    throw new NotSupportedException("")
                }
            }

            return currentException;
        }
    }

    public interface IReturnableVisitor<TItem, TReturn>
    {
        bool CanVisit { get; protected set; }
        TReturn Visit(TItem item);
    }
    /// <summary>
    /// can walk up the exceptions using the visitor
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    public sealed class ExperienceExceptionLogger<TException>
        where TException : ExperienceException
    {
        public TException OriginalException { get; }
        public ExperienceExceptionLogger(TException experienceException )
        {
            // walk up the experience exception coming in
            // until you reach the Experience Exception class
            // Print the log in a hierarchy way to indicate the type of exception to fill out.

            OriginalException = experienceException ?? throw new ArgumentNullException(nameof(experienceException));
        }

        /// <summary>
        /// An Experience Exception has occorred
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class ExperienceExceptionLogEntry
    {
        public ExperienceException ExperienceException { get; }

        public ExperienceExceptionLogEntry(ExperienceException experienceException)
        {
            ExperienceException = experienceException;
        }

        // print all properties that are FriendlyPropertyAttribute marked.
        public override string ToString()
        {
            return base.ToString();
        }
    }

    // Marks a property as being computed, the value is determined via other 
    // class members
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ComputedAttribute : ExperienceAttribute
    {

    }

    // Marks a properties value as being friendly to display to a user.
    // simply having this attribute means your value can be printed.
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class FriendlyPropertyAttribute : ExperienceAttribute
    {
        
    }

    public class ExperienceAttribute : Attribute
    {

    }
}
