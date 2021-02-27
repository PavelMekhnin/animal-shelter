import React from "react";
import { Link, useHistory } from "react-router-dom";
import { IAnimalCard } from "../interfaces/Interfaces";

type AnimalCardProps = {
    card: IAnimalCard,
    shelterId : string
}

export const AnimalCardPreview: React.FC<AnimalCardProps> = (card) => {
    const history = useHistory();
    const url = `/shelter/${card.shelterId}/pet/${card.card.id}`;
    return (
        <div className="animal-card">
            <div className="row">
                <div className="col s12">
                    <div className="card small">
                        <div className="card-image">
                            <img src={card.card.imgUrl} className="activator" />
                        </div>
                        <div className="card-content">
                            <span className="card-title grey-text text-darken-4">{card.card.name}</span>
                            <p><Link to={url}>More</Link></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}