﻿namespace Pokemon.Models
{
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon pokemon { get; set; }
        public Owner owner { get; set; }
    }
}
