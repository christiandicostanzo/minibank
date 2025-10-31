using MiniBank.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System.Reflection;

namespace MiniBank.MongoDB;

public class RegisterClassMapBuilder
{

    private static bool registered = false;

    public static void RegisterMapClasses(Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly, nameof(assembly));

        if(registered)
            throw new RegisterClassMapException("BsonClassMapBuilder already registered.");

        var baseTypeDefinition = typeof(BsonClassMapBuilder<>);

        var types = assembly.GetTypes()
                            .Where(t => t.BaseType != null &&
                                        t.BaseType.Name == baseTypeDefinition.Name)
                            .ToList();

        foreach (var type in types)
        {
            var methodInfo = type.GetMethod("RegisterClassMap");
            var fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name == "map");

            if (methodInfo == null)
            {
                continue;
            }

            var instance = Activator.CreateInstance(type);

            if (instance == null)
            {
                continue;
            }

            try
            {
                methodInfo.Invoke(instance, null);

                var bsonMapClassResult = fieldInfo.GetValue(instance);

                if (bsonMapClassResult is BsonClassMap mapClass && !BsonClassMap.IsClassMapRegistered(type))
                {
                    BsonClassMap.RegisterClassMap(mapClass);
                }

                registered = true;
            }
            catch (TargetInvocationException ex)
            {
                throw new BsonClassMapRegistrationException($"Error invoking RegisterClassMap on type {type.FullName}: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                throw new BsonClassMapRegistrationException($"Unepected error {ex.Message}");
            }
        }

    }

    public static void RegisterDomainBaseTypes()
    {

        BsonClassMap.RegisterClassMap<EntityBase>()
                  .MapField(e => e.EntityId)
                  .SetElementName("entity_id").SetSerializer(new GuidSerializer(GuidRepresentation.Standard));

        var auditableEntityClassMap = BsonClassMap.RegisterClassMap<AuditableEntity>();
        auditableEntityClassMap.MapProperty(a => a.CreatedDate).SetElementName("created_date");
        auditableEntityClassMap.MapProperty(a => a.UpdatedDate).SetElementName("updated_date");
    }
}
