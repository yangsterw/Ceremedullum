# -*- coding: utf-8 -*-
"""
Created on Sun Mar  7 01:33:02 2021

@author: yang
"""
	
from os import makedirs
from os import listdir
from shutil import copyfile
from random import seed
from random import random
# create directories

# dogs = normal
# cats = pneumonia
dataset_home = 'dataset_normal_vs_pneumonia/'
subdirs = ['train/', 'test/']
for subdir in subdirs:
	# create label subdirectories
	labeldirs = ['normal/', 'pneumonia/']
	for labldir in labeldirs:
		newdir = dataset_home + subdir + labldir
		makedirs(newdir, exist_ok=True)
# seed random number generator
seed(1)
# define ratio of pictures to use for validation
val_ratio = 0.25
# copy training dataset images into subdirectories
src_directory = 'dataset_normal_vs_pneumonia/unsorted/'
for file in listdir(src_directory):
	src = src_directory + '/' + file
	dst_dir = 'train/'
	if random() < val_ratio:
		dst_dir = 'test/'
	if file.startswith('person'):
		dst = dataset_home + dst_dir + 'pneumonia/'  + file
		copyfile(src, dst)
	elif file.startswith('IM-'):
		dst = dataset_home + dst_dir + 'normal/'  + file
		copyfile(src, dst)