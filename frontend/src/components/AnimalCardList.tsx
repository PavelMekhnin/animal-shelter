import React from 'react';
import { IAnimalCard } from '../interfaces/Interfaces';
import { AnimalCardPreview } from './AnimalCardPreview';
import { Link } from 'react-router-dom';
import { AnimalList } from './AnimalList';

type AnimalList = {
    list: IAnimalCard[],
    shelterId: string
}

export const AnimalCardList: React.FC<AnimalList> = ({ list, shelterId }) => {
    if (list == null || list.length == 0) {
        return (<span>The shelter does not have any animals yet :(</span>)
    }
    var link = `/shelter/${shelterId}/pets`
    return (
        <>
        <div>
            <div className="row">
                <h5 className="center-align">Our animals</h5>
            </div>
            <div className="row">
                {list.slice(0, 4).map(card => {
                    return (
                        <div className="col s6">
                            <AnimalCardPreview card={card} shelterId={shelterId} key={card.id}></AnimalCardPreview>
                        </div>
                    )
                })
                }
                <Link to={link}>See all</Link>
            </div>

        </div>
        </>
    )
}