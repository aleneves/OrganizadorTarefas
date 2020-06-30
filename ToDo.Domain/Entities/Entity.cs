using System;

namespace ToDo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        //Classe base para outrs entidades
        //Uso do abstract para que nunca seja instanciada, pois a Entity sozinha não faz sentido.

        public Entity()
        {
            Id = Guid.NewGuid(); //Gerado sempre que a classe é instanciada.
        }

        public Guid Id { get; private set; }

        public bool Equals(Entity other)
        {
            //Comparação de duas entidades através do ID.
            return Id == other.Id;
        }
    }

}