import React from 'react';
import { IAnimalCard } from '../interfaces/Interfaces';
import { AnimalCardPreview } from './AnimalCardPreview';

type AnimalList = {
    list: IAnimalCard[],
    shelterId : string
}

export const AnimalCardList: React.FC<AnimalList> = ({ list , shelterId}) => {
    if (list.length == 0) {
        return (<span>На настоящий момент у приюта нет питомцев :(</span>)
    }
    return (
        <div>
            {list.map(card => {
                return (
                    <div className="col s6">
                        <AnimalCardPreview card={card} shelterId={shelterId} key={card.id}></AnimalCardPreview>
                    </div>
                )
            })
            }
        </div>
    )
}