import React from "react";
import { IAnimalCard } from "../interfaces/Interfaces";

type AnimalCardProps = {
    card: IAnimalCard
}

export const AnimalCardPreview: React.FC<AnimalCardProps> = (card) => {

    return (
        <div className="animal-card">
            <div className="row">
                <div className="col s12">
                    <div className="card small">
                        <div className="card-image">
                            <img src={card.card.img_url} className="activator" />
                        </div>
                        <div className="card-content">
                            <span className="card-title grey-text text-darken-4">{card.card.name}</span>
                            <p><a href="#">Пдробнее</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}