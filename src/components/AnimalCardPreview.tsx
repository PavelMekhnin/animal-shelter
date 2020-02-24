import React from "react";
import { IAnimalCard } from "../interfaces/Interfaces";

type AnimalCardProps = {
    card : IAnimalCard
}

export const AnimalCardPreview: React.FC<AnimalCardProps> = (card) => {

    return (
        <div className="animal-card">
            <div className="row">
                <div className="col s12">
                    <div className="card">
                        <div className="card-image">
                            <img src={card.card.img_url} />
                            <span className="card-title">{card.card.name}</span>
                        </div>
                        <div className="card-content">
                            <p>{card.card.description}</p>
                        </div>
                        <div className="card-action">
                            <a href="#">Подробнее</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}