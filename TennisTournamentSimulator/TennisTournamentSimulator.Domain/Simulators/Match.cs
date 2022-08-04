﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournamentSimulator.Domain.Entities;

namespace TennisTournamentSimulator.Domain.Simulators
{
    public interface IMatch {
        Player Play();
    }
    public abstract class Match: IMatch
    {
        public Player ParticipantA { get; private set; }
        public Player ParticipantB { get; private set; }
        public abstract Player Play();

        public Match(Player participantA, Player participantB)
        {
            ParticipantA = participantA;
            ParticipantB = participantB;
        }
    }
}