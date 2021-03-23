import React from "react";
import { Link } from "react-router-dom";
import { IShelterCardPreview } from "../interfaces/Interfaces";

type ShelterCardProps = {
    card: IShelterCardPreview
}

export const ShelterCardPreview: React.FC<ShelterCardProps> = (card) => {
    const url = `/shelter/${card.card.id}`
    return (
        <Link to={url}>
            <div className="col s12 l6">
                <div className="card-panel grey lighten-5 z-depth-1">
                    <div className="row valign-wrapper">
                        <div className="col">
                            <div style={{ backgroundImage: "url(" + card.card.logoUrl + ")" }} className="circle square-img logo" />
                        </div>
                        <div className="col">
                            <div className="row">
                                <h5 className="orange-text">
                                    {card.card.title}
                                </h5>
                            </div>
                            <div className="row"></div>
                            <span className="black-text">
                                {card.card.address}
                            </span>
                        </div>
                    </div>
                </div>
            </div >
        </Link>
    )
}